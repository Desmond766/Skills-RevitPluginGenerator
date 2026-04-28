---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.AddResolution(Autodesk.Revit.DB.FailureResolutionType,Autodesk.Revit.DB.FailureResolution)
source: html/b9c1a05a-80ac-6dcc-2af3-a010081d933f.htm
---
# Autodesk.Revit.DB.FailureMessage.AddResolution Method

Adds a resolution for the failure.

## Syntax (C#)
```csharp
public FailureMessage AddResolution(
	FailureResolutionType type,
	FailureResolution resolution
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - The type of the resolution.
- **resolution** (`Autodesk.Revit.DB.FailureResolution`) - The resolution.

## Returns
The FailureMessage.

## Remarks
Each pair of FailureResolutionType and FailureResolution must have been defined in FailureDefinition,
 and could only be added once.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - type is not a valid resolution type for this FailureMessage.
 -or-
 resolution of type is not valid for this FailureMessage.
 -or-
 This FailureMessage already contains a resolution of type type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessage is already posted to a document

