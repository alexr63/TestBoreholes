# TestBoreholes data model (draft)

The data model contains locations of water sources and their properties.

A location is defined by a latitude, and a longitude. The latitude and longitude are given in degrees. The latitude is positive for the northern hemisphere and negative for the southern hemisphere. The longitude is positive for the eastern hemisphere and negative for the western hemisphere.

A location has a city name, and a country name.

A location has a water source. The water source is one of the following: river, lake, spring, well, rain, pond, stream or borehole.

A borehole has a depth. The depth is given in meters.

A borehole has an Id. The Id is given as a string value.

A borehole has an owner. The owner is given as a string value.

A borehole has a status. The status is one of the following: pumping, or damaged.

A pumping borehole has a flow rate. The flow rate is given in liters per minute.

A pumping borehole has an estimated daily operations cost. The estimated daily operations cost is given in US dollars.

A damaged borehole has a damage type. The damage type is one of the following: minor or major.

A damaged borehole has an estimated repair cost. The estimated repair cost is given in US dollars.

A damaged borehole has an estimated repair time. The estimated repair time is given in days.

A damaged borehole has a list of required services to repair. The service is one of the following: concrete, construction, generator, pipe, power, pressure rubber, solar, tank, tap, pump, motor, or electrical.
