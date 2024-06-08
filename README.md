# Image Dataset!

Downloaded cartoon faces dataset from [Kaggle](https://www.kaggle.com/datasets/brendanartley/cartoon-faces-googles-cartoon-set).

# Project Planning!
**Keeping scalability at the forefront**; Memory management would be crucial for this project because the project heavily relies on sprites. I'm going to use asset bundles for this, and then dynamically retrieve sprites during runtime from the asset bundle. For now; I'm going to host this asset bundle locally. However, for server hosting, would need to be cautious about asset availability before level load, which I will not consider at the moment.
