---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinition.AddResolutionType(Autodesk.Revit.DB.FailureResolutionType,System.String,System.Type)
source: html/0f62a4a7-e91e-7061-e3a2-26eb86a6402b.htm
---
# Autodesk.Revit.DB.FailureDefinition.AddResolutionType Method

Adds a type of possible resolution for the failure.

## Syntax (C#)
```csharp
public FailureDefinition AddResolutionType(
	FailureResolutionType type,
	string caption,
	Type classOfResolution
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - Type of the resolution to add. The type of resolution can be used only once for the FailureDefinition.
- **caption** (`System.String`) - A simple description of the resolution.
- **classOfResolution** (`System.Type`) - The runtime class of the resolution. Used to ensure that the actual FailureResoution object added to the instance of FailureMessage
 belongs to an applicable class.

## Returns
The FailureDefinition.

## Remarks
In order to inform Revit what failure resolutions can be possibly used with a given failure, a FailureDefinition must
 contain a full list of resolution types applicable to the failure, including user-visible caption and runtime class of the
 resolution. The number of resolutions is not limited. The first added resolution becomes the default resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The type has already been added as a resolution to the FailureDefinition.
 -or-
 The input classOfResolution is not a subclass of FailureResolution.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

