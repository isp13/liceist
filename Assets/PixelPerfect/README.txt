PixelPerfect 2.1 by Pixelatto
============================
A tool to make texture texels correspond 1:1 to physical pixels

DEMO SCENE CONTENTS:
PixelPerfectComparisonDemo - A simple example of the Pixel Perfect system: a "Common Camera" VS "PixelPerfect Camera" side by side
PixelPerfectPhysicsDemo - An example on how to use "PixelPerfect" with Unity default 2D physics
PixelPerfectParallaxDemo - An example on how to use "PixelPerfect" with perspective cameras + parallax

QUICK START GUIDE:
1. Import "Pixel Perfect" package into your project
2. Drag the "Pixel Perfect Camera" component into your camera GameObject
3. Drag the "Pixel Perfect Sprite" into as many sprites as you like
4. Enjoy

UPGRADE GUIDE:
1. Remove old PixelPerfect folder
2. Import the new PixelPerfect package

TIPS:
- As the rendering internals of Unity change between versions, a "Sub-Pixel Offset" property has been added. Adjust it in case you notice artifacts.
- Use the "Pixelated" render mode for a retro look (avoids sub-texel pixels)
- Camera Target Pixel Height: how many texels would you like to see vertically
- For physics & moving objects, set the "PixelPerfectSprite" objects as childs and check the "Use Parent Transform" flag. Then, apply the movement to the parent.
- Disable the "Run Continously" flag on your "PixelPerfectSprite" components to improve runtime performance
- If you want to use a different "World Pixel Size", change the corresponding value in the class "PixelPerfect/Scripts/Internal/PixelPerfect"

Get more assets at: www.pixelatto.com

If you need any help: support@pixelatto.com