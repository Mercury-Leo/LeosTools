# Leo's tools

This package contains Editor scripts that enhances development flow, for me at least.

## Tools
* Folder generation
* Scene Selection
* Template creator 
* Enhanced Logger

### Folder Generation
The Folder generation tools gives a few options in the creation menu.
Under Create -> Folders you can find the following folders:
* Scripts & Prefabs
* Scripts & Interfaces
* ScriptableObjects
* Scripts & ScriptableObjects

As I tend to create quite a lot of folders while designing, this saves me a few clicks a day.

The tool also comes with a menu option to create a base project folder setup.
Under Tools -> SetUp -> Create Base Project
This will create a folder structure in the assets folder like so:
`_Project
---- AppUI
---- Core
---- Game
---- Scenes`

### Scene Selection
The Scene selection tool is baed on the talented Warped Imganiation's video on the subject.
The tool creates an overlay that allows for quick scene changes, mostly good when there are a lot of scenes.
In the Project settings, under Tools -> Scene Selection Overlay, you can find an option to change the tool to use additive scenes.
The tool itself has an option to switch between showing scenes that are in the build, to showing all the available scenes.

### Template Creator
The Template Creator tool adds useful templates as a qulity of life feature.
Under Create -> Templates you can find the following templates:
* Interface
* Scriptable Object
* Class
* StaticClass
* Enum

### Enhanced Logger
The Enhanced Logger is a logger that implements ILogHandler.
The logger adds to the Unity console colors for the Debug prints.
To activate the logger, add the following line:
`Debug.unityLogger.logHandler = new EnhancedLogger();`
Make sure this line runs in some preloading scene to make sure it takes effect.

Unfourntly, the Enhanced Logger is the only tool that has specific lines of code that need to be run to be used.

----------------------------

If you have any suggestions, feel free to contant me.
