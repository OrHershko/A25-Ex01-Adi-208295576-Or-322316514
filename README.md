# Facebook Desktop Application

This project is a C# Windows Forms application that allows users to interact with their Facebook account. It provides features for viewing profile information, news feed, friends list, photo albums, liked pages, and posting status updates. The application also includes experimental features for sorting liked pages and a weather check functionality, possibly integrated with Facebook events.

## Project Structure

The project is organized into the following main directories:

*   `/FacebookWinFormsApp`: Contains the Windows Forms UI code, including the main application window, dialogs, and custom controls. This is the entry point of the application.
*   `/FacebookAppLogic`: Houses the business logic of the application. This includes classes for managing application state, specific feature logic like the Guess Game and Weather Check, and potentially data transformation or processing.
*   `/FBApi`: Contains the Facebook API wrapper (`Facebook.dll`, `FbGraphApiWrapper.dll`). This library is responsible for all communication with the Facebook Graph API. The `ReleaseNotes - READ ME!!.txt` file in this directory provides a changelog for this wrapper.

## Features

*   **Facebook Login/Logout:** Securely log in and out of your Facebook account.
*   **Profile Information:** View your basic profile information, including name and profile picture.
*   **News Feed:** Browse your Facebook news feed.
*   **Friends List:** View your list of friends.
*   **Photo Albums:** Browse your photo albums and their pictures.
*   **Liked Pages:** View pages you have liked.
*   **Post Status:** Update your Facebook status directly from the application.
*   **Sort Liked Pages:** An experimental feature to sort your liked pages (details on sorting criteria might require further code exploration).
*   **Weather Check:** An experimental feature that seems to be related to checking weather, possibly for Facebook events (details might require further code exploration).
*   **Guess Game:** The `FacebookAppLogic` folder contains `GuessGameLogic.cs`, suggesting a guess game feature.

## How to Run

This project is a C# Windows Forms application developed using Visual Studio.
1.  Clone the repository.
2.  Open the solution file (`.sln`) in Visual Studio.
3.  Build the solution.
4.  Run the `FacebookWinFormsApp` project.

Note: The application uses the Facebook API. You might need to configure API keys or permissions for full functionality. The login currently attempts to use a hardcoded App ID or a token, which might need to be updated or replaced with a valid one. The application also copies `design.patterns20cc` to the clipboard on startup, which might be related to login credentials for a test account.

## Facebook API Wrapper

This project utilizes a specific version of a Facebook API wrapper located in the `/FBApi` directory. This wrapper includes `Facebook.dll` and `FbGraphApiWrapper.dll`. For details regarding the version history and changes within this wrapper, please refer to the `FBApi/ReleaseNotes - READ ME!!.txt` file.
