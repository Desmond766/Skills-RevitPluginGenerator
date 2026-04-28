---
kind: method
id: M:Autodesk.Revit.DB.PhaseFilter.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/2f346b3e-3cf6-f529-80f1-15a33f406519.htm
---
# Autodesk.Revit.DB.PhaseFilter.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new phase filter with default status presentation.

## Syntax (C#)
```csharp
public static PhaseFilter Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The name.

## Returns
The newly created phase filter.

## Remarks
The default status presentation is ShowByCategory for New status, and ShowOverriden for Existing,
 Demolished and Temporary statuses.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is already in use.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

