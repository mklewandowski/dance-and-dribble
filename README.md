# Dance 'n' Dribble
Inspired by Double Dunk and the NBA playoffs, Dance 'n' Dribble is a basketball simulation.  It just doesn't feature much basketball. Dance, curse out a ref, promote potato chips, and do a bunch of other odd things as you take on the role of a professional athlete.

## Gameplay
Follow onscreen instructions and tap or click to play each of the mini-games.

![Dance 'n' Dribble gameplay](https://github.com/mklewandowski/dance-and-dribble/blob/main/Assets/Images/dance-dribble-gameplay.gif?raw=true)

## Supported Platforms
Dance 'n' Dribble is designed for use on multiple platforms including:
- iOS
- Android
- Web
- Mac and PC standalone builds

## Running Locally
Use the following steps to run locally:
1. Clone this repo
2. Open repo folder using Unity 2021.3.27f1
3. Install Text Mesh Pro

## Building the Project

### WebGL Build
For embedding within itch.io, we use the `better-minimal-webgl-template` seen here:
https://seansleblanc.itch.io/better-minimal-webgl-template

Setup of the `better-minimal-webgl-template` is as follows:
1. Download and unzip the template.
2. Copy the `WebGLTemplates` folder into the `Assets` folder.
3. File -> Build Settings... -> WebGL -> Player Settings... -> Select the "BetterMinimal" template.
4. Enter color in the "Background" field.
5. Enter "false" in the "Scale to fit" field to disable scaling.
6. Enter "true" in the "Optimize for pixel art" field to use CSS more appropriate for pixel art.

### Running a Unity WebGL Build
1. Install the "Live Server" VS Code extension.
2. Open the WebGL build output directory with VS Code.
3. Right-click `index.html`, and select "Open with Live Server".

## Development Tools
- Created using Unity
- Code edited using Visual Studio Code
- Sounds created using [Bfxr](https://www.bfxr.net/)
- Audio edited using [Audacity](https://www.audacityteam.org/)
- 2D images created and edited using [Paint.NET](https://www.getpaint.net/)

## Credits
- Pixel art based on Double Dunk on the Atari VCS games.
- For embedding within itch.io, we use the `better-minimal-webgl-template` seen here:
https://seansleblanc.itch.io/better-minimal-webgl-template