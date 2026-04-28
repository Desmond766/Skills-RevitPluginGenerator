---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.CreateHanger(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,System.Int32,Autodesk.Revit.DB.ElementId)
source: html/4bc39956-696d-6e15-ecf2-da469fb205e8.htm
---
# Autodesk.Revit.DB.FabricationPart.CreateHanger Method

Creates a free placed hanger.

## Syntax (C#)
```csharp
public static FabricationPart CreateHanger(
	Document document,
	FabricationServiceButton button,
	int condition,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button to use.
- **condition** (`System.Int32`) - The condition index. If the button has multiple conditions.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level identifier associated with the level.

## Returns
The newly-created fabrication hanger.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid fabrication service button.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

