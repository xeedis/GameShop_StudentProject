import requests
import json
import sys
import re

"""
Program is used to search for useful text, image urls, video url on official steam website
to assist, when adding product to the shop app. Each command saves found items as .json file, for
easier use by C# used as back-end language.

TODO:
- Should program also download text data? What text data should be downloaed?

Commands:
getGameInfo
description: Returns text describing usage of available commands.
output: Text in console.

getGameInfo -name [arg]
description: Searches for games containing inputed arg phrase. Arg can consist of multiple word separated
by space.
input: arg :string and/or int
output: Text in console and output in .json file.

getGameInfo -appid [arg]
description: Searches for data of game with specified appid, and saves it to .json file.
input: arg: integer - number of application
output: Text in command line, and output in .json file. 
"""


def update_game_list():
    """
    Downloads a dictionary containing all games avalable on steam and saves it to all_games_data.json file
    :return: None
    """
    api_url = 'https://api.steampowered.com/ISteamApps/GetAppList/v0002/'

    data_string = requests.get(api_url).text

    with open("all_games_data.json", "w", encoding="utf-8") as f:
        f.write(data_string)


def search_for_game_id(game_name: str):
    """
    Searches all_games_data.json file for occurences of game_name phrase, and saves findings to
    found_games_data.json file.
    :param game_name: string containing name of the game
    :return: list containing found games as well as their id's
    """
    with open('all_games_data.json', 'r', encoding="utf-8") as file:
        parsed = json.load(file)
    games_list = parsed["applist"]["apps"]

    found_games = []
    print(f"Searching for {game_name}")
    # Search for keyword game_name in available application names
    for i in games_list:
        if game_name.lower() in i["name"].lower():
            app_id = i["appid"]
            app_name = i["name"]
            found_games.append([app_name, app_id])
    print("Found:", found_games)
    file_content = {}
    with open("found_games_data.json", "w") as f:
        for game_info in found_games:
            file_content[game_info[0]] = game_info[1]
        json.dump(file_content, f)
    return found_games


def get_game_webpage(appid: int):
    """
    Writes HTML content of specified website to website_data.txt file
    :param appid: - ID of the game
    :return: None
    """
    base_url = "https://store.steampowered.com/app/"
    game_page_data = requests.get(base_url + str(appid)).text
    with open('website_data.txt', 'w', encoding="utf-8") as f:
        f.write(game_page_data)


def find_media_urls():
    """
    Searches website_data.txt file for images and videos and saves findings to
    found_media.json file
    :returns: list containing text info and image/video URL'S
    """
    with open('website_data.txt', 'r', encoding="utf-8") as f:
        steam_html_data = f.read()

    pattern_img_main = r'(?:href=\")(https:\/\/cdn\.akamai\.steamstatic\.com\/steam\/apps\/[^"]*)'
    pattern_img_alt = r'(?:href=\")(https:\/\/cdn\.cloudflare\.steamstatic\.com\/steam\/apps\/[^"]*)'
    pattern_vid_main = r'(?:data-webm-source=\")(https:\/\/cdn\.akamai\.steamstatic\.com\/steam\/apps\/[^"]*)'
    pattern_vid_alt = r'(?:data-webm-source=\")(https:\/\/cdn\.cloudflare\.steamstatic\.com\/steam\/apps\/[^"]*)'

    img = re.findall(pattern_img_main, steam_html_data)
    img.extend(re.findall(pattern_img_alt, steam_html_data))
    vid = re.findall(pattern_vid_main, steam_html_data)
    vid.extend(re.findall(pattern_vid_alt, steam_html_data))

    result = {
        "text": [],
        "image": [],
        "video": [],
    }

    for image in img:
        result["image"].append(image)
    for video in vid:
        result["video"].append(video)

    with open("found_media.json", "w") as f:
        json.dump(result, f)
    return result


# Checks for arguments, and parameters
opts = [opt for opt in sys.argv[1:] if (opt.startswith("-") and len(sys.argv) >= 1)]
args = [arg for arg in sys.argv[1:] if (not arg.startswith("-") and len(sys.argv) >= 1)]
arg = " ".join(args)


# Specifies available commands
if "-update" in opts or "-u" in opts:
    update_game_list()
    print("Created all_games_data.json file.")
elif args and ("-name" in opts or "-n" in opts):
    test = "-name" in opts or "-n" in opts
    print("Found games, -appid parameter to search for app info and media in Steam.")
    search_for_game_id(arg)
elif args and ("-appid" or '-id' or "-a" in opts):
    print("Found media will be saved to found_media.json file:")
    get_game_webpage(arg)
    print(find_media_urls())
else:
    raise SystemExit(f"Usage: {sys.argv[0]} (-name | -appid) <argument>")


def test():
    # For testing purposes, can be modified or deleted
    with open("found_media.json", "r") as f:
        a = json.load(f)
        print(json.dumps(a, indent=2))  # prints to console prettified json file contents

# test()
