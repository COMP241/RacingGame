# Digital Paper Game Example Project

Clone this project, delete `.git` directory, and `git init`, or do the following in your Unity project to start a new project:

1. Add this project's .gitignore.
2. Go to `Edit > Project Settings > Editor > Asset Serialization` and ensure it is Force Text.
3. Also in Editor Settings ensure Version Control is Visible Meta Files.

It's probably best for different members to work in different scenes because scenes (and prefabs, somewhat) do not merge very well. After merging branches, manually merge scenes into a new master reference scene, commit and push, and work on separate copies again.

*Note: This project is set up for 2D, so if you want to switch to 3D, change `Edit > Project Settings > Editor > Default Behaviour Mode` to 3D, change the scene view to 3D and change the camera to perspective/make a new camera*

When we are certain on format of .json files (hopefully by next meeting) I'll make a simple json to object decoder, so we don't have to write one separately for each project.
