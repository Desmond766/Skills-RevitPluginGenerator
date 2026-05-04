---
kind: method
id: M:Autodesk.Revit.DB.SharedParameterElement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalDefinition)
zh: 创建、新建、生成、建立、新增
source: html/c6430d77-b3e5-2a67-02b2-4896f83ba932.htm
---
# Autodesk.Revit.DB.SharedParameterElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new shared parameter element in the document representing the parameter stored in the input ExternalDefinition.

## Syntax (C#)
```csharp
public static SharedParameterElement Create(
	Document document,
	ExternalDefinition sharedParameterDefinition
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **sharedParameterDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - Shared parameter definition.

## Returns
The newly created shared parameter instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A shared parameter with the assigned GUID is already loaded into the document.

