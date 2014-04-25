HistoryApi
==========

C\# history API with queries by location

Dependencies
-------------

Entity Frameworks provides "Spacial" library with a DbGeography object which has some useful methods for geospacial data, I just used Latitude and Longitude and the `Distance` method. 


Functionality
-------------

It works by defining routes in the `webconfig` file and pointing to methods that correspond to those routes. I defined an URI pattern for `api/{zoom]/{lat}/{lon}` and another for `api/events`.

The events one gets all data.

The Query one finds the two closest points to the Latitude and Longitude provided, in this case via a search button. This uses the `DbGeography` library to create geographical points (dynamically from lat & long via references in a Geolocation get method) and for distance comparisons.

Database
----------------

I set up a database from the model Events and created seed data from my hardcoded events. After setting up the DbContext, `enable-migrations`, and doing an initial migration I still had some problems.
* I need the geography field to create itself
* I need it to be formatted in a special way.

I overcame these problems by replacing the complicated `get` method with a standard `{ get; set; }` block and including a public method `AddGeolocation()` which can be called when adding each event. The actual code looks like this:

	events.ForEach(s => s.AddGeolocation());
	events.ForEach(s => context.Events.AddOrUpdate(p => p.Id, s));
	context.SaveChanges();

Another migration and the database is populated perfectly, queries work and all is good in the world.

Azure
--------------
Migrating to Azure test to follow.

Live version
-----------------

http://nci-testapi.azurewebsites.net/