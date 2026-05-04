---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationItemFile,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/c97c5736-053f-f45b-cf0a-a560fd8b4b13.htm
---
# Autodesk.Revit.DB.FabricationPart.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a fabrication part element from a fabrication item file.

## Syntax (C#)
```csharp
public static FabricationPart Create(
	Document document,
	FabricationItemFile itemFile,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **itemFile** (`Autodesk.Revit.DB.FabricationItemFile`) - The fabrication item file.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The element identifier associated with the Level 
 the FabricationPart will be created on.

## Returns
The new fabrication part.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The item file is not valid for use in Revit.
 -or-
 The item file has not been loaded into the configuration.
 -or-
 The ElementId levelId is not a Level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

