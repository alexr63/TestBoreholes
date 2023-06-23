# TestBoreholes data model (draft)

## The data model represents a location entity.

A location is labeled with a city name, and a country name.

A location has a latitude, and a longitude. The latitude and longitude are given in degrees. The latitude is positive for the northern hemisphere and negative for the southern hemisphere. The longitude is positive for the eastern hemisphere and negative for the western hemisphere.

At a location people can get fresh water from a water source. The water source is one of the following: river, lake, spring, well, rain, pond, stream or borehole.

## The data model represents a river entity.

A river has a name. The name is given as a string value.

A river has a flow rate. The flow rate is given in liters per minute.

## The data model represents a lake entity.

A lake has a name. The name is given as a string value.

A lake has a surface area. The surface area is given in square meters.

## The data model represents a spring entity.

A spring has a name. The name is given as a string value.

A spring has a flow rate. The flow rate is given in liters per minute.

## The data model represents a well entity.

A well has a name. The name is given as a string value.

A well has a depth. The depth is given in meters.

## The data model represents a rain entity.

A rain has a precipitation rate. The precipitation rate is given in liters per minute.

## The data model represents a pond entity.

A pond has a name. The name is given as a string value.

A pond has a surface area. The surface area is given in square meters.

## The data model represents a stream entity.

A stream has a name. The name is given as a string value.

A stream has a flow rate. The flow rate is given in liters per minute.

## The data model represents a borehole entity.

A borehole has a depth. The depth is given in meters.

A borehole has an Id. The Id is given as a string value.

A borehole has an owner. The owner is given as a string value.

A borehole has a status. The status is one of the following: pumping, damaged, or being repaired.

A borehole contains a list of required services.

A borehole contains a list of performed services.

### The data model represents a pumping borehole entity.

A pumping borehole has a flow rate. The flow rate is given in liters per minute.

A pumping borehole has an estimated daily operations cost. The estimated daily operations cost is given in moneys.

### The data model represents a damaged borehole entity.

A damaged borehole has a damage severity. The damage severity is one of the following: low, medium, or high.

A damaged borehole has an estimated repair cost. The estimated repair cost is given in moneys.

A damaged borehole has an estimated repair time. The estimated repair time is given in time spans.

### The data model represents a borehole being repaired entity.

A borehole being repaired has a daily repair cost. The daily repair cost is given in moneys.

### The data model represents required service entity.

A required service has a type. The type is one of the following: concrete, construction, electrical, mechanical, plumbing, pump, steel, other.

A required service has an estimated cost. The estimated cost is given in moneys.

A required service has an estimated duration. The estimated duration is given in time spans.

A required service has a due date. The due date is given in date/time values.

### The data model represents performed service entity.

A performed service has a type. The type is one of the following: concrete, construction, electrical, mechanical, plumbing, pump, steel, other.

A performed service has a cost. The cost is given in moneys.

A performed service has a durarion. The duration is given in time spans.

A performed service has an end date. The end date is given as date/time values.
