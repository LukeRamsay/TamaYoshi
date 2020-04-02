# TamaYoshi
#### A 3rd Year interactive development Project
###  

# Introduction
This is my 3rd year interactive development term 1 project.

We were tasked with creating a cross platform virtual pet app using Xamarin forms, Microsoft's cross platform development tool. This virtual pet is required to have about 3 needs which will need to be attended to at different intervals each with different interactions. The app needs to work on both Android and IOS and needs to include at least 3 unit tests.

# Concept 

The virtual pet app market is one that is very saturated, there are plenty apps that let you take care of  a virtual dog, cat, fish, plant or even a monster but there are very few virtual pet apps that let you take care of a pet that is an easily recognizable character and I think there’s a huge missed opportunity there. So because of this I decided to make my virtual pet app a modern tamagotchi clone using Yoshi from the Super Mario series as my pet. 
This means that my users are more likely to be gamers or they could be people who know of or have played the Mario series or people who know Yoshi from his own games. Both of these games have massive playerbases. Additionally the target users would be children as they are the ones that actually use virtual pet apps.


# Getting started
#### Prerequisites 

* This was made in [Visual Studio for Mac]( https://visualstudio.microsoft.com/vs/mac/ ) 
* The user interface was mainly designed to work on the iphone 11
* You will probably need xcode if you plan on deploying it to an IOS device

#### How to Install

1. Clone or download the project
```sh
git clone https://github.com/LukeRamsay/TamaYoshi.git
```

2. Open Up the Project in visual studio

3. Start a new project in Xcode to get a new bundle identifier

4. Navigate to the info.plist file and replace the bundle identifier with your own bundle identifier

5. Manage the NuGet packages if you need to, I used Rg.Plugins and Xam.Plugins.SimpleAudioPlayer

6. Build the project to your device or simulator of choice
    (Iphone 11 is was what I designed around)

# Running Unit Tests
#### On Mac you can press COMMAND + SHIFT + T to run all the unit tests

There are 15 unit tests, testing to see if all the need and age states will change properly. They pretty much all look like this. 

```sh
    [TestMethod()]
    public void AgeTestMethod()
        {
            var AgeStates = new AgeStates();
            AgeState ageState = AgeState.teen;
            var expectedResult = "teen";

            AgeState result = AgeStates.GetAgeState(expectedResult);

            Assert.AreEqual(ageState, result);
        }
```


# Features and functionality
1. 4 Deycaying Needs
2. Name and Rename your Yoshi
3. Swipe Gestures
4. Sounds on button presses
5. Popup modal
6. Alive time counter
7. Birth time capturer
8. Yoshi can **die**

# Built with

* c# 
* Xamarin
* Xamarin Forms

# Contributing

Feel Free to contribute and help me out

1. Fork the Project
2. Create your Branch
3. Commit your Changes and push them
4. Open a Pull Request

# Authors
 * **Luke Ramsay** - *Everything* - Student

# License 
Distributed under the MIT License. See `LICENSE` for more information.

# Acknowledgements
#### Thanks to ......

* My Lecturers Paul and Armand
* [Houssem Dellai]( youtube.com/channel/UCCYR9GpcE3skVnyMU8Wx1kQ )
* Wolf from [Pixilart]( pixilart.com )
* [Adrian]( https://devblogs.microsoft.com/xamarin/adding-sound-xamarin-forms-app/ )