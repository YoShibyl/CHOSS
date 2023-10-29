# CHOSS - Clone Hero OBS Scene Switcher
A websocket-based automatic scene switcher for OBS v28+, for use with Clone Hero and YARG.  Requires OBS v28 or newer.

![image](https://github.com/YoShibyl/CHOSS/assets/18250695/f55c912c-8b34-4529-9e9d-30279309cc41)


## Prerequisites
- Windows 10 or newer
- [OBS](https://obsproject.com) v28 or newer, with at least two scenes set up (one for gameplay, and one for menus)
- [Clone Hero](https://clonehero.net), [ScoreSpy CH](https://clonehero.scorespy.online) or [YARG](https://yarg.in)

## Setup
In order to use CHOSS, you need to configure your OBS websocket server.

### OBS setup
1) Click **Tools > WebSocket Server Settings**.  Make sure **Enable WebSocket Server** is checked.
2) ***It is strongly recommended to use a password for authentication, preferably one that is generated.***  To do this, check the **Enable Authentication** box, click **Generate Password**, and then click **Apply**.  You only need to do this once.
3) Click the **Show Connect Info** button, and copy the password that was generated.  You'll need this to connect CHOSS to the websocket server.
4) *(optional)* If connecting to a WebSocket on a different PC running OBS, you'll need the local IP address of that PC.  Otherwise, leave the IP as `localhost`, `127.0.0.1`, or `0.0.0.0`

### CHOSS setup
5) Select the configuration for the game you're playing.
6) Click **Browse for currentsong.txt**, and select the game's `currentsong.txt` file.
    - If playing ScoreSpy CH, the file is located in your ScoreSpy installation's folder.
    - If playing regular CH, the file is located in the `Clone Hero` folder within your Documents folder.
    - If playing YARG, it should be located at `C:\Users\YOURNAME\AppData\LocalLow\YARC\YARG\currentSong.txt`
7) Enter the password of your OBS WebSocket server in the password field.
8) Enter the names of the Gameplay and Menu/stats scenes under Scene Switcher settings, making sure they're the same as the scenes you want to switch between in OBS.
    - Generally, you'll want to have the gameplay scene show your webcam behind the game (with Game Capture transparency enabled or a cutout mask), and the menu scene should have your webcam in the corner with the game capture behind it.
9) Click **Save Configuration** to remember these settings for later.
10) Click Connect, and you should be all set to stream/record gameplay!

## Credits and Special Thanks
- [obs-websocket-dotnet](https://github.com/BarRaider/obs-websocket-dotnet) : Without this, CHOSS would have been much more difficult to make.
- [Clone Hero](https://clonehero.net), [ScoreSpy CH](https://clonehero.scorespy.online), [YARG](https://yarg.in), and the community
  - Check out these awesome streamers:
    - Acai : https://twitch.tv/Acai
    - Frif : https://twitch.tv/Frif
    - Jason : https://twitch.tv/JasonParadise
    - Me : https://twitch.tv/YoShibyl
- Also, shoutout to Acai's Discord server, where it was suggested that I use WebSocket rather than hotkeys to make this scene switcher.
