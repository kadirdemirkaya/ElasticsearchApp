
# ElasticSearchAPI

This project is an elastic search themed project consisting of a simple API and form projects.




## Features and Content

In this project, the Api project was used as BackEnd and the Form project was used as Client.

CRUD operations on the product\
Logging\
Category and Country filtering\
Autocomplete with letters and patterns\
Repository and Services

- ElasticsearchAPI
    Food Controller:
    - `GET api/Food/ApplySeedData`: Applies SeedData.
    - `GET api/Food/AllProduct`: Gets all products.
    - `POST api/Food/AddProduct`: Adds products.
    - `DELETE api/Food/DeleteProduct`: Deletes products.
    - `GET api/Food/GetProduct`: Gets product based on ID.
    - `PUT api/Food/UpdateProduct`: The product updates.
    - `GET api/Food/AutoCompleteWithSearch`: It aims to find the initial letter or words containing the initials of the given word in a text.
    - `GET api/Food/AutoComplete`: Allows finding words containing a certain pattern.
    - `GET api/Food/CountryFilter`: Filters by city.
    - `GET api/Food/CategoryFilter`: Filters by category.

- ElasticsearchForm
    

## Loading

First pull the project

```bash
 git clone https://github.com/kadirdemirkaya/ElasticsearchApp.git
```

Change the information in the extension location

```bash
 appsettings.json
```

Get the API Project up and running

```bash
 dotnet run
```


## Form Image

![ElasticApp](https://github.com/kadirdemirkaya/ElasticsearchApp/assets/126807887/4b1d653e-484f-4f8a-a6cd-3fcd67fcc9d3)


