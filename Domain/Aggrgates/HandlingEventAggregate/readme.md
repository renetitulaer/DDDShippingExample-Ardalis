From the blue book:
Handling Event and Carrier Movement: We care about such individual incidents
because they allow us to keep track of what is going on. They reflect real-world events,
and those are not usually interchangeable, so they are ENTITIES. Each Carrier Movement
will be identified by a code obtained from a shipping schedule.
Another discussion with a domain expert concludes that Handling Events can be uniquely
identified by the combination of Cargo Id, completion time, and type. For example, the
same cargo cannot be both loaded and unloaded at the same time

About the repository
For now there is no Handling Event Repository because we decided to implement the
association with Delivery History as a collection in the first iteration, and we have no
application requirement to find out what has been loaded onto a Carrier Movement. Either
of these reasons could change, and then we would add a REPOSITORY.
