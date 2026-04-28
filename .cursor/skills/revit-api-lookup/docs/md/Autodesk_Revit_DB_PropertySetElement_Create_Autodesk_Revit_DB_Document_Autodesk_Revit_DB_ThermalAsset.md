---
kind: method
id: M:Autodesk.Revit.DB.PropertySetElement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ThermalAsset)
zh: 创建、新建、生成、建立、新增
source: html/cad9dcdd-0c26-e960-9646-c23349dc6ab5.htm
---
# Autodesk.Revit.DB.PropertySetElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new PropertySetElement to contain the given asset.

## Syntax (C#)
```csharp
public static PropertySetElement Create(
	Document document,
	ThermalAsset thermalAsset
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the PropertySetElement.
- **thermalAsset** (`Autodesk.Revit.DB.ThermalAsset`) - The thermal asset containing the values that will be present in the PropertySetElement.

## Returns
The new PropertySetElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the name of the asset is empty, contains prohibited characters, or is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

