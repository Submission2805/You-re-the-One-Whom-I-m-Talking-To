# Supplementary Material for CHI 2025 Submission 2805

## Overview
This repository provides key server-side logic and Example Data for the VR Multi-Agent Simulation platform described in the manuscript. The platform is designed to enable real-time interaction between road users (e.g., pedestrians, cyclists, manual vehicle drivers) and an autonomous vehicle (AV) in a shared virtual environment.

The material focuses on the server's role in managing data synchronization and controlling AV behavior. It is shared to facilitate the review process and enhance the understanding of the platform's core functionalities.

While the client-side implementations are not included in this repository due to their dependency on specific hardware configurations, we are actively working on finalizing a complete open-source API that will include all server and client-side functionalities, as well as detailed documentation. This effort is part of our commitment to supporting research transparency and reproducibility within the Automotive UI community.

## File Descriptions
1. **Code Files**:
    - `serverController_cyclist.cs`: Manages cyclist position and rotation data on the server and updates it for connected clients.
    - `serverController_driver.cs`: Synchronizes driver position, rotation, and vehicle-specific data (e.g., wheel rotations) for connected clients.
    - `pedestrianController.cs`: Updates the pedestrian's position and rotation data and sends it to connected clients.
    - `receiveMsg.cs`: Processes server messages to control AV behavior (e.g., stopping or resuming movement).
    - `AVMoves.cs`: Simulates AV dynamics, including acceleration, deceleration, and eHMI signaling.

2. **Example Data**:
    - `ExampleData/SampleInput.json`: Simulated input data sent by a client (e.g., cyclist) to the server (pedestrian).
    - `ExampleData/SampleOutput.json`: Processed data forwarded by the server to other clients (e.g., driver).

## Instructions for Use
1. **Set Up the Environment**:
    - Install Unity (version 2021.3.14f1).
    - Install and configure the Mirror API for server-client communication.

2. **Clone the Repository**:
    Clone the repository to your local machine using the following command:
    ```bash
    git clone https://github.com/Submission2805/You-re-the-One-Whom-I-m-Talking-To.git
    ```

3. **Load the Code**:
    - Add the provided `.cs` files to your Unity project's `Assets` folder.

4. **Test the Server Logic**:
    - Use `SampleInput.json` to simulate input data from a client to the server.
    - Run the server (`ServerController_Pedestrian.cs`) and observe the output.
    - Compare the generated output with `SampleOutput.json` to validate the server's functionality.

## Notes
- This repository focuses on server-side logic for the VR Multi-Agent Simulation platform.
- We are actively preparing a comprehensive open-source API that will include all functionalities described in the manuscript. This API will be released with full documentation and example use cases, ensuring it can support further research and development.
