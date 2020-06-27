How to build (tested on Windows and Ubuntu):
  - Clone project
  - Open project folder in Visual Code
  - Press F5 to build and run the project
  
Project description:  
Console application which emulates 2 processes that are exchanging data via messages. Communication happens via loopback on port 31415 for Process A and port 31416 for Process B.

Strengths:  
  - The system runs fully parallel. For each process there are is a single send-thread but receive-threads spawn on demand/connect. Furthermore, the consumer-part of the process runs as an Actor implementation and thus decouples itself completely from network dependencies, guaranteeing that the consumer is never stuck in network read-operations.
  - Messages are sent with strong encryption. [Curve25519](https://en.wikipedia.org/wiki/Curve25519) is used for the key exchange and [AES256](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard) is used for the symmetric data transfer.
  - Message and Serialization are dummy implementations and can be replaced easily by e.g. JSON format.
  - The program is small. Excluding the library-code, the complete program is implemented with effectively 168 lines of code.
  - Network/Crypto library is open source. As it is developed and maintained by myself, every part of the project can be adjusted or changed on demand.
  
  Weaknesses:  
  - System relies on underlying TCP protocol for data integrity. This may be considered too weak depending on the application.
  - Library is not an industrial standard. Interoperability with other systems is not guaranteed.
  - The system does not scale. It was built as a proof of concept and would require extra effort to split the system into scalable parts.
