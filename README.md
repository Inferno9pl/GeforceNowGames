# GeforceNowGames
A console application that allows you to check what games you have are available on the **Nvidia Geforce Now** streaming service. 


## Inspiration
Geforce Now is an NVIDIA streaming platform that is getting more and more popular. It allows you to run previously purchased games, e.g. on Steam, Epic Store. It offers a great selection of games, but not all games from the Steam library are available on the service.

To check this, GFN allows you to link a Steam account. All yours Steam games that are in GFN will be detected and added to the library automatically.

But this functionality is missing for games from Epic Games. When you link an Epic account, the only benefit you get is faster logging into Fortnite. 

This is the reason I wrote this application. The app allows you to check which Epic games are available on GFN.


## Current solution 
NVIDIA offers this site [Geforce Now Games](https://www.nvidia.com/en-us/geforce-now/games/) where you have a list of all supported games.
But there is no option to set a filter and get a list of all Epic Games Store games. There is also no way of comparing your entire game library to the NVIDIA database.


## Running the application
After downloading the package, extract it, and just double-click GeforceNowGames.exe file. 
What will you see: 
```
1 - Show all games on GeforceNow
2 - Show all games by store
3 - Show owned games by store
exit - close App
```
Then just write `1`, `2`, `3`, or `exit` (then press **ENTER**) to execute selected position. In the next step, just do what the app requires of you.


## Available functions
The application has 3 main functionalities:
- listing all games available on the Geforce Now streaming service 
- listing all these games according to the store (eg. Steam, Epic, Ubisoft Connect)
- listing which games from your list, are available on service


## Inline Command execution
Another option to use this application is using a Command Prompt (CMD). Write in CMD: `<location_of_GeforceNowGames.exe> <location_of_owned_games> <store_name>`, press **Enter** and the application will show you all of your games available on GFN in the selected store (eg. Epic, Steam).

### For example:
```C:\Users\John\Desktop\GeforceNowGames_v1.0.0\GeforceNowGames.exe C:\Users\John\Desktop\GeforceNowGames_v1.0.0\ExampleGameList\ExampleMyEpicGames.txt Epic```

Will give you the below result:
```
Games from the user's list, available on GFN and from Epic:
       1 Alan Wake                                  Action, Adventure,
       2 Enter the Gungeon                          Action, Adventure, Indie,
       3 For Honor                                  Action, Adventure,
       4 Kingdom: New Lands                         Indie, Simulation, Strategy,
       5 Moonlighter                                Action, Adventure, Indie,
       6 Overcooked                                 Action, Casual, Family, Indie, Simulation,
```


## Tips
On your list of owned games, the game titles should be written as accurately as possible. To better match the titles, the app will remove all trademarks, spaces, dashes, and other symbols before making a comparison.
Each game should be written on a separate line without commas and hyphens at the end of the line. Example text file can be found in v1.0.0 Release.
