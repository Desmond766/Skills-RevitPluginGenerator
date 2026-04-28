---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.SetPresenceOfSegments(System.Boolean,System.Boolean,System.Boolean)
source: html/bf3d88bc-f9a7-e224-bfd7-e04f75f4d38f.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.SetPresenceOfSegments Method

Simultaneously set the presence of all 3D segments.

## Syntax (C#)
```csharp
public void SetPresenceOfSegments(
	bool isDuplicateShapePresent,
	bool isStartConnectorPresent,
	bool isEndConnectorPresent
)
```

## Parameters
- **isDuplicateShapePresent** (`System.Boolean`)
- **isStartConnectorPresent** (`System.Boolean`)
- **isEndConnectorPresent** (`System.Boolean`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The shape is disconnected or forms a complete loop:
 If the duplicate shape is present, exactly one of the connectors must be present.

