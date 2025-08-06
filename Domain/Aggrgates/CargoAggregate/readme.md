*From the blue book:  
Cargo -> Two identical boxes must be distinguishable, so they are ENTITIES. In practice all
shipping companies assign tracking ID’s to each. This id will be automatically generated,
visible to the user, and, in this case, probably conveyed to the customer at booking time.*

*Delivery History: This is a tricky one. Delivery Histories are not interchangeable, so they
are ENTITIES. But a Delivery History has a one-to-one relationship with its Cargo, so it
doesn’t really have an identity of its own. Its identity is borrowed from the Cargo that owns
it. This will become clearer when we model the AGGREGATES.*

*Delivery Specification: Although it represents the goal of a Cargo, the abstraction does
not depend on Cargo. It really expresses a hypothetical state of some Delivery History.
We hope that the Delivery History attached to our Cargo will eventually satisfy the Delivery
Specification attached to our Cargo. But if we had two cargoes going to the same place
they could share the same Delivery Specification, while they could not share the same
History, even though the histories start out the same (empty). Specifications are VALUE
OBJECTS.*

*There is one circular reference: Cargo knows its Delivery History which holds a series of
Handling Event, which in turn point back to the Cargo. Circular references logically exist in
many domains and are sometimes necessary in design as well, but they are tricky to
maintain. Implementation choices can help by avoiding holding the same information in two
places that mush be kept synchronized. In this case, we can use a simple but fragile
implementation in an initial prototype, with an Array List (Java) of Handling Events in
Delivery History. But at some point we’ll probably want to drop the collection in favor of a
database lookup with Cargo as the key. This discussion will be taken up again when
choosing REPOSITORIES. If the query to see the history is relatively infrequent, this should
give good performance and simplify maintenance and reduce the overhead of adding
Handling Events. If this query is very frequent, then it is better to go ahead and maintain
the direct pointer. These design tradeoffs are based on simplicity of implementation and
on performance. The model is the same, and contains the cycle and the bi-directional
association.*

Notes:
- strange implementation choice
- it's also stated that this is a fragile implementation and a prototype
- handling Event is an aggregate root without a repository
- therefore the Cargo will persist the Handling Events via the Delivery History
- there is a method to add a Handling Event to the Delivery History

*Cargo is also an obvious AGGREGATE root, but where to draw the boundary takes some thought.
We could sweep in everything that only exists because of this Cargo, which would include
the Delivery History, the Delivery Specification, and the Handling Events. The Delivery
History seems to be something no one would look up directly without the Cargo itself. With
no need for direct global access, and with an identity that is really just derived from the
Cargo, the Delivery History fits nicely inside of Cargo’s boundary, and does not need to be
a root. The Delivery Specification is a VALUE OBJECT, so that presents no complications.
The Handling Event is another matter. Previously we have considered two possible
database queries that would search for these: one to find what was loaded onto a
particular Carrier Movement; another as a possible alternative to finding the Handling
Events for a Delivery History, which would be local within the Cargo AGGREGATE. It seems
that the activity of handling the Cargo has some meaning even when considered apart
from the Cargo itself. It could be drawn either way. It should be the root of its own
AGGREGATE.**

