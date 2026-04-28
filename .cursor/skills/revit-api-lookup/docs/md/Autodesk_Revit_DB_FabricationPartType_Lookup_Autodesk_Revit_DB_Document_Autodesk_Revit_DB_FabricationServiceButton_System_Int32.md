---
kind: method
id: M:Autodesk.Revit.DB.FabricationPartType.Lookup(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,System.Int32)
source: html/5b71bce4-f161-6f8c-48dd-96f745990157.htm
---
# Autodesk.Revit.DB.FabricationPartType.Lookup Method

Looks up an existing fabrication part type based on a specfic fabrication service button and condition.

## Syntax (C#)
```csharp
public static ElementId Lookup(
	Document document,
	FabricationServiceButton button,
	int condition
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button.
- **condition** (`System.Int32`) - The condition index.

## Returns
Identifier of the fabrication part type element or invalidElementId if no fabrication part type exist for the
 specific fabrication service button and condition

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

