# AspNetCore.OpenSearchElasticDemo

## Overview

This ASP.NET Core demo application integrates with OpenSearch, Zipkin, and Elasticsearch. It demonstrates how to use these technologies for distributed tracing and search functionalities.

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET 8.0 SDK or later](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/AspNetCore.OpenSearchElasticDemo.git
cd AspNetCore.OpenSearchElasticDemo



## 2. Build and Run Docker Services

To build and start the required services (OpenSearch, Elasticsearch, Zipkin, and others), use Docker Compose:

```bash
docker-compose up -d


## Starting Services

This command will start the following services:

- **OpenSearch**: A distributed search and analytics engine, running with two nodes and OpenSearch Dashboards.
- **Elasticsearch**: A search and analytics engine used for various search functionalities.
- **Zipkin**: A distributed tracing system for monitoring and troubleshooting microservices-based applications.
- **OpenTelemetry Collector**: Collects telemetry data such as traces and metrics from your services.
- **Data Prepper**: Processes data pipelines for transforming and routing data.
- **ASP.NET Core Application**: The main application being developed and tested.



### 3.Environment Variables

Set up the following environment variables in your local environment or Docker Compose file:

- **OPENSEARCH_HOSTS**: List of OpenSearch node URLs, e.g., `http://localhost:9202`.
- **ELASTICSEARCH_HOSTS**: URL for Elasticsearch, e.g., `http://localhost:9200`.
- **ELASTIC_PASSWORD**: Password for Elasticsearch.
- **KIBANA_PASSWORD**: Password for Kibana (if used).
- **ENCRYPTION_KEY**: Encryption key for securing Kibana.
