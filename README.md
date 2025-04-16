# About PasswordTree

So many times, I wanted to get a instant password but all common password generators are the same. they have a list and then a random function, in which the random function might select same character

## Password Generator
I create a tree for generating password whose selection is based on level 1 nodes of tree which is topics (Letter, Number, Symbol)
This PassTree select from leaves of tree then checks if this topic is selected before or not

![image](https://github.com/user-attachments/assets/70f115ac-6333-4880-a72e-f072b7d1924c)


## Decision Tree
PasswordTree can select same topic after 0 to 2 times(when there is 3 topics), which we call it "Selection Cooldown"
![image](https://github.com/user-attachments/assets/45a78d72-2f0d-4146-be6b-ea7e81d8f135)

You can even select which leaves you prefer to be selected by app via Settings panel
![image](https://github.com/user-attachments/assets/272a7a6a-a1e8-4787-92f9-d674ae89df12)


## Installation

### Windows 7
For windows 7 you have to install [.Net Frameworkd 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-offline-installer) first, then install [PasswordTree](https://github.com/PasswordTree/PasswordTree/releases/tag/releases)

### Windows 10 & 11
For windows 10 & 11 there is no dependency for installing [PasswordTree](https://github.com/PasswordTree/PasswordTree/releases) as long as they included .Net Framework 4.8
