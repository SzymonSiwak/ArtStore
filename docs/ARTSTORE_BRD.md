# ARTSTORE - Business Requirements Document (BRD)

**Project:** Reorganization of the homepage and category structure of the art store  
**Status:** Artstore (v1.1)

## 1. The aim of the project
The project's goal is to implement a new homepage layout and revamp the product categorization logic to improve user experience (UX) and facilitate product navigation.

**Scope of changes:**
* Implementation of new homepage graphic design.
* Retention of existing sections: Bestsellers, New Arrivals.
* Removal of sections: Living, Stationary.
* Introduction of a new product section: Artworks.
* Restructuring of product taxonomy by introducing two independent navigational axes: Categories and Collections.

## 2. System Gap Analysis & New Requirements
While analyzing the new design, I identified gaps between the current database structure (Domain Model) and the new requirements:

* **Dynamic Dictionary Management:** Previously, categories were hardcoded into the system. The new requirements mandate that store administrators be empowered to dynamically create, edit, and delete both Categories and Collections directly from the management panel.
* **Multiplicity of relations:** According to the new model, a single product has a specific main theme (it must be assigned to exactly one Category) but can simultaneously fit various styles or interiors (it must support assignment to multiple Collections concurrently). The current system requires expansion to support multiple attributions.
* **Cross-filtering:** Due to the introduction of two navigational axes, the system must allow a user browsing a specific Collection to further narrow down search results by selecting a specific Category (and vice versa - filtering Collections within a selected Category).

## 3. Functional Requirements & Architectural Decisions

### REQUIREMENT 1: BUSINESS LOGIC AND DATABASE STRUCTURE

* **Current model modification**
  Removal of the static list of categories from the system structure.
* **Introduction of new business entities**
  * **Category:** The system must process and store the name, description, and a unique, SEO-friendly URL (slug) for each category.
  * **Collection:** The system must process and store the name, description, SEO-friendly URL (slug), and a dedicated promotional image (banner) for each collection.
* **Data migration**
  A new set of product data corresponding to the new section (Artworks) must be imported into the database.

### REQUIREMENT 2: RETRIEVING DATA

* **Category and Collection Handling**
  The backend system (API) must provide interfaces that allow seamless retrieval of comprehensive lists of available Categories and Collections for the user interface.
* **Product Management**
  * Separate mechanisms for retrieving bestseller lists and category-specific products must be deprecated in favor of a single, unified search and filtering mechanism.
  * This filtering mechanism must support new parameters: Category attribution, Collection attribution, Bestseller status, and New Arrival status.
* **Homepage Data Provisioning**
  The logic aggregating data for the homepage must be modified. The compilation should exclude deprecated sections (Living, Stationary) and dynamically provide data on Featured Collections and newly added Artworks in their place.

### REQUIREMENT 3: FILTER LOGIC

* **Query Parameterization**
  Search interfaces must be updated to accept queries based not only on names but also on dedicated identifiers and URLs (slugs) for Categories and Collections, as well as status flags (Bestseller, New Arrival).
* **Interface Expansion**
  Product subpages (e.g., Artworks) must provide users with filters enabling seamless switching between specific Categories and Collections.

### REQUIREMENT 4: UI BEHAVIOR AND ROUTING (SEO)

* **Static and SEO-friendly URLs**
  Main product listing pages must utilize human-readable web addresses based on "slug" values. Instead of operating with internal identifiers in the address bar, the system should generate links such as `/category/{friendly-name}` (e.g., `/category/space`).
  
  The frontend application is responsible for reading a given URL, identifying the corresponding category/collection within the system based on it, and loading the appropriate product list by treating that identifier as the view's "base filter."

### REQUIREMENT 5: NEW DESIGN OF UI

* **Homepage and navigation**
  Implementation of an entirely new layout for the homepage and navigation bar (navbar), in accordance with the approved design mockups (Figma assets).
* **Subpages**
  Complete decommissioning and removal of subpages dedicated to the retired Living and Stationary sections from the store's views.