# About PasswordTree

So many times, I wanted to get a instant password but all common password generators are the same. they have a list and then a random function, in which the random function might select same character
I create a tree for generating password whose selection is based on level 1 nodes of tree which is topics (Letter, Number, Symbol)
This PassTree select from leaves of tree then checks if this topic is selected before or not. PasswordTree can select same topic after n times too which we can it "Selection Cooldown". You can even select which leaves you prefer to be selected by app via Settings panel

## Installation

### Windows 7

For windows 7 you have to install [.Net Frameworkd 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-offline-installer) first, then install [PasswordTree](https://github.com/PasswordTree/PasswordTree/releases/tag/password)

### Windows 10 & 11

For windows 10 & 11 there is no dependency for installation as long as they included .Net Framework 4.8
