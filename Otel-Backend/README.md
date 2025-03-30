# OpenTelemetry

Repository containing the demo projects used in my workshop presentation
It consists out of 2 ASP.NET Web API services and 1 Service worker. The communication between the services is done with RabbitMQ, the Loan API will push a message to the queue and the Service worker will pick this up and process it.
The processing of the message will trigger calls to the Catalog API.

Logging is done with SeriLog and it uses an OpenTelemetry Sink to export logs to an OpenTelemetry Collector.
Traces are collected using the OpenTelemetry auto instrumentation for .NET.

The infrastructure setup through docker can be found in separate folder, that will spin up everything together.
