import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

// Vehicle Class
class Vehicle {
    private String vehicleId;
    private String vehicleType;
    private int capacity; // Capacity in tons

    public Vehicle(String vehicleId, String vehicleType, int capacity) {
        this.vehicleId = vehicleId;
        this.vehicleType = vehicleType;
        this.capacity = capacity;
    }

    public String getVehicleId() {
        return vehicleId;
    }

    public String getVehicleType() {
        return vehicleType;
    }

    public int getCapacity() {
        return capacity;
    }

    @Override
    public String toString() {
        return "Vehicle ID: " + vehicleId + ", Type: " + vehicleType + ", Capacity: " + capacity + " tons";
    }
}

// Shipment Class
class Shipment {
    private String shipmentId;
    private String destination;
    private int weight; // Weight in tons
    private String assignedVehicleId = "Not Assigned";

    public Shipment(String shipmentId, String destination, int weight) {
        this.shipmentId = shipmentId;
        this.destination = destination;
        this.weight = weight;
    }

    public String getShipmentId() {
        return shipmentId;
    }

    public String getDestination() {
        return destination;
    }

    public int getWeight() {
        return weight;
    }

    public String getAssignedVehicleId() {
        return assignedVehicleId;
    }

    public void assignVehicle(String vehicleId) {
        this.assignedVehicleId = vehicleId;
    }

    @Override
    public String toString() {
        return "Shipment ID: " + shipmentId + ", Destination: " + destination + 
               ", Weight: " + weight + " tons, Assigned Vehicle: " + assignedVehicleId;
    }
}

// Transportation Management System Class
public class TransportationManagementSystem {
    private List<Vehicle> vehicles = new ArrayList<>();
    private List<Shipment> shipments = new ArrayList<>();
    private Scanner scanner = new Scanner(System.in);

    public void run() {
        while (true) {
            System.out.println("\n--- Transportation Management System ---");
            System.out.println("1. Add a Vehicle");
            System.out.println("2. Add a Shipment");
            System.out.println("3. Assign Shipment to Vehicle");
            System.out.println("4. View All Vehicles");
            System.out.println("5. View All Shipments");
            System.out.println("6. Exit");
            System.out.print("Choose an option: ");
            int choice = scanner.nextInt();
            scanner.nextLine(); // Consume newline

            switch (choice) {
                case 1 -> addVehicle();
                case 2 -> addShipment();
                case 3 -> assignShipmentToVehicle();
                case 4 -> viewAllVehicles();
                case 5 -> viewAllShipments();
                case 6 -> {
                    System.out.println("Exiting the system. Goodbye!");
                    return;
                }
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }
    }

    // Method to add a vehicle
    private void addVehicle() {
        System.out.print("Enter Vehicle ID: ");
        String vehicleId = scanner.nextLine();
        System.out.print("Enter Vehicle Type (e.g., Truck, Van): ");
        String vehicleType = scanner.nextLine();
        System.out.print("Enter Vehicle Capacity (in tons): ");
        int capacity = scanner.nextInt();
        scanner.nextLine(); // Consume newline

        Vehicle vehicle = new Vehicle(vehicleId, vehicleType, capacity);
        vehicles.add(vehicle);
        System.out.println("Vehicle added successfully.");
    }

    // Method to add a shipment
    private void addShipment() {
        System.out.print("Enter Shipment ID: ");
        String shipmentId = scanner.nextLine();
        System.out.print("Enter Shipment Destination: ");
        String destination = scanner.nextLine();
        System.out.print("Enter Shipment Weight (in tons): ");
        int weight = scanner.nextInt();
        scanner.nextLine(); // Consume newline

        Shipment shipment = new Shipment(shipmentId, destination, weight);
        shipments.add(shipment);
        System.out.println("Shipment added successfully.");
    }

    // Method to assign a shipment to a vehicle
    private void assignShipmentToVehicle() {
        System.out.print("Enter Shipment ID to assign: ");
        String shipmentId = scanner.nextLine();
        Shipment shipment = findShipmentById(shipmentId);

        if (shipment == null) {
            System.out.println("Shipment not found.");
            return;
        }

        System.out.print("Enter Vehicle ID to assign to shipment: ");
        String vehicleId = scanner.nextLine();
        Vehicle vehicle = findVehicleById(vehicleId);

        if (vehicle == null) {
            System.out.println("Vehicle not found.");
        } else if (shipment.getWeight() > vehicle.getCapacity()) {
            System.out.println("Shipment weight exceeds vehicle capacity.");
        } else {
            shipment.assignVehicle(vehicleId);
            System.out.println("Shipment assigned to vehicle successfully.");
        }
    }

    // Method to find a vehicle by ID
    private Vehicle findVehicleById(String vehicleId) {
        for (Vehicle vehicle : vehicles) {
            if (vehicle.getVehicleId().equals(vehicleId)) {
                return vehicle;
            }
        }
        return null;
    }

    // Method to find a shipment by ID
    private Shipment findShipmentById(String shipmentId) {
        for (Shipment shipment : shipments) {
            if (shipment.getShipmentId().equals(shipmentId)) {
                return shipment;
            }
        }
        return null;
    }

    // Method to view all vehicles
    private void viewAllVehicles() {
        if (vehicles.isEmpty()) {
            System.out.println("No vehicles available.");
        } else {
            System.out.println("\n--- List of Vehicles ---");
            for (Vehicle vehicle : vehicles) {
                System.out.println(vehicle);
            }
        }
    }

    // Method to view all shipments
    private void viewAllShipments() {
        if (shipments.isEmpty()) {
            System.out.println("No shipments available.");
        } else {
            System.out.println("\n--- List of Shipments ---");
            for (Shipment shipment : shipments) {
                System.out.println(shipment);
            }
        }
    }

    // Main method to run the system
    public static void main(String[] args) {
        TransportationManagementSystem tms = new TransportationManagementSystem();
        tms.run();
    }
}


