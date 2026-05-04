---
kind: property
id: P:Autodesk.Revit.DB.Element.Parameter(System.Guid)
zh: 参数、共享参数
source: html/2e852bc4-46c6-5598-cc45-0eaf38cf8973.htm
---
# Autodesk.Revit.DB.Element.Parameter Property

**中文**: 参数、共享参数

Retrieves a parameter from the element given a GUID for a shared parameter.

## Syntax (C#)
```csharp
public Parameter this[
	Guid guid
] { get; }
```

## Parameters
- **guid** (`System.Guid`) - The unique id associated with the shared parameter.

## Remarks
Parameters are a generic form of data storage within elements. The parameters are visible
through the Autodesk Revit user interface in the Element Properties dialog. This method is used to
retrieve a parameter for a known shared parameter. When a shared parameter is created it is
assigned a Guid which will not change. This guid can be used to retrieve the piece of data from the
element at a later time.

