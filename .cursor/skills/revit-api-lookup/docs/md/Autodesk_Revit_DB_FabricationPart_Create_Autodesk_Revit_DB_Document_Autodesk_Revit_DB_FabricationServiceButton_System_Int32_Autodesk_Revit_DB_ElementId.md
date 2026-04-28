---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,System.Int32,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/cbd8fff5-a923-aa42-1464-534e082c79f0.htm
---
# Autodesk.Revit.DB.FabricationPart.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a fabrication part element based on button.

## Syntax (C#)
```csharp
public static FabricationPart Create(
	Document document,
	FabricationServiceButton button,
	int condition,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button to use.
- **condition** (`System.Int32`) - The condition index.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The element identifier associated with the Level 
 the FabricationPart will be created on.

## Returns
The new fabrication part.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Fabrication service button contains invalid fittings.
 -or-
 Please use FabricationPart.CreateHanger to create fabrication hanger.
 -or-
 The ElementId levelId is not a Level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fabrication part type does not exist. Reload the service using FabricationConfiguration.LoadServices.

