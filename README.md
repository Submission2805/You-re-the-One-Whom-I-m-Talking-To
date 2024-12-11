# Supplementary Material for CHI 2025 Submission 2805

## Overview
This repository contains the core scripts and key server-side logic for a VR Multi-Agent Simulation platform, focusing on server-client interactions, AV behavior control as described in the manuscript. The platform is designed to enable real-time interaction between road users (e.g., pedestrians, cyclists, manual vehicle drivers) and an autonomous vehicle (AV) in a shared virtual environment.

The material focuses on the server's role in managing data synchronization and controlling AV behavior. It is shared to facilitate the review process and enhance the understanding of the platform's core functionalities.

While the client-side implementations are not included in this repository due to their dependency on specific hardware configurations, we are actively working on finalizing a complete open-source API that will include all server and client-side functionalities, as well as detailed documentation. This effort is part of our commitment to supporting research transparency and reproducibility within the HCI and Automotive research community.

## File Descriptions
- `serverController_cyclist.cs`: Synchronizes cyclist position and rotation data and updates it for connected clients in the simulation.
- `serverController_driver.cs`: Manages driver position, rotation, and vehicle-specific data (e.g., wheel rotations) for accurate simulation of manual vehicle dynamics.
- `pedestrianController.cs`: Synchronizes pedestrian movement data and handles eHMI interactions.
- `receiveMsg.cs`: Handles server-side message reception and processes commands to control AV behavior in various interaction scenarios.
- `AVMoves.cs`: Controls AV behaviors, including yielding, mixed, and non-yielding modes, with collision handling.

## Notes
- This repository focuses on server-side logic for the VR Multi-Agent Simulation platform.
- We are actively preparing a comprehensive open-source API that will include all functionalities described in the manuscript. This API will be released with full documentation and example use cases, ensuring it can support further research and development.
