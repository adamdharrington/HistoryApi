HistoryApi
==========

C\# history API with queries by location

Dependencies
-------------

Entity Frameworks provides "Spacial" library with a DbGeography object which has some useful methods for geospacial data, I just used Latitude and Longitude. 

I installed the `Geo` library to query distance.

Functionality
-------------

It works by defining routes in the `webconfig` file and pointing to methods that correspond to those routes. I defined an URI pattern for `api/{zoom]/{lat}/{lon}` and another for `api/events`.

The events one gets all data.

The Query one finds the two closest points to the Latitude and Longitude provided, in this case via a search button. This uses the `DbGeography` library to create geographical points (dynamically from lat & long via references in a Geolocation get method) and the `Geo` library for distance comparisons.

Live version
-----------------

http://nci-testapi.azurewebsites.net/