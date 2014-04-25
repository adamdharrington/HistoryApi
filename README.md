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
Migration to Azure was a pain! Basically, it all comes down to a thing called `PublishSettings` in the Azure management console. When creating a website from Azure you can set up your database automatically, however if you do so from Visual studio you must set up the database separately, link it to the website, copy database connection string (the top tcp one) and add it under `website` > `configure` > `Connection Strings` with the name equal to your DbContext.

Also, after `updating` and `downloading` your new publish settings you must import these into your visual studio project in the the publish wizard *profile* section. The only other thing is to check the box to *execute code first migrations* for the selected DbContext, this poulates the database the first time the application runs (may take time). That should be it.

Live version
-----------------

http://nci-testapi.azurewebsites.net/