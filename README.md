Readme

Description

This repository contains a system for saving and loading data both locally and from a server. The system includes an abstract base class called BaseDataSave, which is inherited by two classes: JsonSaveSystem and BinarySaveSystem. These classes implement the ISaveData interface, which includes two methods: T Load<T>(string key) and void Save(string key, object data). When data is saved, it is stored in memory under a specific key.

There is also a class called SimpleDataSaveSystem, which extends PlayerPrefs and implements ISaveData. This class is useful for storing simple game settings.

Finally, there is a class called CloudSaveSystem<SystemType>, which implements ISaveData and accepts and processes data from a server. It can also load data from the server.

Installation

To use this system, you can simply clone the repository and import the necessary files into your project.

Usage

To save data locally, create an instance of either JsonSaveSystem or BinarySaveSystem and call the Save method with a key and the data to be saved. To load data, call the Load method with the key.

To use SimpleDataSaveSystem, create an instance and call the Save and Load methods as with the other classes.

To use CloudSaveSystem, create an instance and call the Save and Load methods as with the other classes. However, note that this class requires a connection to a server and may require additional configuration.

Contributing

If you would like to contribute to this repository, please submit a pull request.
