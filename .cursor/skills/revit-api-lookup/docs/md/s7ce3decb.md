---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,System.Double,System.Double,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/82f4580e-0461-e307-1926-d26eb99841d7.htm
---
# Autodesk.Revit.DB.FabricationPart.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a fabrication part element based on button and size.

## Syntax (C#)
```csharp
public static FabricationPart Create(
	Document document,
	FabricationServiceButton button,
	double width,
	double depth,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button to use. Matches button condition based on the specified size.
- **width** (`System.Double`) - The width of the part. Units are in feet (ft).
- **depth** (`System.Double`) - The depth of the part. Units are in feet (ft). It should be equal to width for round part.
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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fabrication part type does not exist. Reload the service using FabricationConfiguration.LoadServices.
 -or-
 failing to match a button condition based on specific size.

