---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.RemoveFabricReinforcementSystem(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.FabricArea)
source: html/f3972463-e0b1-6998-a12e-20ee51fbd6f0.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.RemoveFabricReinforcementSystem Method

Deletes the specified FabricArea, and converts its FabricSheet elements
 to equivalent Single Fabric Sheet elements.

## Syntax (C#)
```csharp
public static IList<ElementId> RemoveFabricReinforcementSystem(
	Document doc,
	FabricArea system
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.
- **system** (`Autodesk.Revit.DB.Structure.FabricArea`) - An FabricArea Reinforcement element in the document.

## Returns
The ids of the newly created Single Fabric Sheet elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element system was not found in the given document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

