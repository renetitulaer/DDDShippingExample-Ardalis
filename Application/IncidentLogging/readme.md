﻿- This application component is used by the Incident Logging Application to record handle events
- Hnadling event is an aggreate in the domain model
- But is does not have a repository
- When a new handling event is created, it is added to the Delivery History of the Carrier Movement
- Cargo will save the handling event in the Delivery History
- In the blue book this is called a fragile implementation and a prototype
- In the next iteration we will maybe add a repository for Handling Events