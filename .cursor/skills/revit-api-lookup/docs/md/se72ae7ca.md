---
kind: method
id: M:Autodesk.Revit.DB.MEPSystem.GetSectionByIndex(System.Int32)
zh: 系统
source: html/dd53cbe2-37e6-19a1-e627-74a2aacb3433.htm
---
# Autodesk.Revit.DB.MEPSystem.GetSectionByIndex Method

**中文**: 系统

Get the section from the index.

## Syntax (C#)
```csharp
public MEPSection GetSectionByIndex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the section in the system.

## Returns
The section.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The section index is out of range.

