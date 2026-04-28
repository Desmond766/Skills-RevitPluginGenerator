---
kind: method
id: M:Autodesk.Revit.DB.DeleteWorksetSettings.#ctor(Autodesk.Revit.DB.DeleteWorksetOption,Autodesk.Revit.DB.WorksetId)
source: html/3ff52b4f-b8f1-a4c7-4afd-a62375e55a16.htm
---
# Autodesk.Revit.DB.DeleteWorksetSettings.#ctor Method

Constructs a DeleteWorksetSettings object.

## Syntax (C#)
```csharp
public DeleteWorksetSettings(
	DeleteWorksetOption deleteWorksetOption,
	WorksetId elementsMoveInto
)
```

## Parameters
- **deleteWorksetOption** (`Autodesk.Revit.DB.DeleteWorksetOption`)
- **elementsMoveInto** (`Autodesk.Revit.DB.WorksetId`)

## Remarks
elementsMoveInto only takes effect when DeleteWorksetOption::Enum is MoveElementsToWorkset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

