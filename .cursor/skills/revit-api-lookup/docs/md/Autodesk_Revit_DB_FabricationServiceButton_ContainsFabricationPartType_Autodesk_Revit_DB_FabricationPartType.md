---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.ContainsFabricationPartType(Autodesk.Revit.DB.FabricationPartType)
source: html/345e1c56-258b-ea7f-f3db-0058ec324cf6.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.ContainsFabricationPartType Method

Checks to see if the fabrication part type exists on one of the button conditions.

## Syntax (C#)
```csharp
public bool ContainsFabricationPartType(
	FabricationPartType partType
)
```

## Parameters
- **partType** (`Autodesk.Revit.DB.FabricationPartType`) - The fabrication part type to check.

## Returns
Returns true if the fabrication part type exists on the fabrication service button.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

