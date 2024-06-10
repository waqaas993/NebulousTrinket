# Image Dataset!

Downloaded cartoon faces dataset from [Kaggle](https://www.kaggle.com/datasets/brendanartley/cartoon-faces-googles-cartoon-set).

# Project Planning!
**Keeping scalability at the forefront**; Memory management would be crucial for this project because the project heavily relies on sprites. I'm going to use asset bundles for this, and then dynamically retrieve sprites during runtime from the asset bundle. For now; I'm going to host this asset bundle locally. However, for server hosting, would need to be cautious about asset availability before level load, which I will not consider at the moment. I will use combination of Observer pattern, MVC, & Singletons. Observer patterns are my favorites, so you will see them a lot in the codebase, I will try to avoid singletons but there're situations where you just can't. You will also see some generic type implementation and polymorphism to obtain general functionality. I know MVC would complicate things a little bit, but in my opinion it just segregates the data and view logic in a very nice way and keeps the dependencies to the controller.

# Usage!
Find the Board Configs scriptable object in project to change board sizes.

# Note!
The project is still missing a few things but it gives a nice overview of how I implement systems.
