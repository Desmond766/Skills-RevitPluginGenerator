---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHookType.Create(Autodesk.Revit.DB.Document,System.Double,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/e113d22a-0e59-6642-e45d-2538a0d24bff.htm
---
# Autodesk.Revit.DB.Structure.RebarHookType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new RebarHookType in a document.

## Syntax (C#)
```csharp
public static RebarHookType Create(
	Document doc,
	double angle,
	double multiplier
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **angle** (`System.Double`) - Determine the hook angle of new RebarHookType.
- **multiplier** (`System.Double`) - Determine the straight line multiplier of new RebarHookType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for angle is not a number
 -or-
 The given value for multiplier is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - angle must be greater than 0 and no more than pi.
 -or-
 multiplier must be greater than 0 and no more than 99.

