---
kind: property
id: P:Autodesk.Revit.UI.PromptForFamilyInstancePlacementOptions.FaceBasedPlacementType
source: html/9dfeb2be-d4cc-54ad-5c59-4e8a72400283.htm
---
# Autodesk.Revit.UI.PromptForFamilyInstancePlacementOptions.FaceBasedPlacementType Property

The placement type to be used if prompting to place an instance of a face-based family.
 This option is ignored if placing a non-face-based family. If placing a face-based family, Default is an acceptable value, but will correspond to the first available selection in the user interface.

## Syntax (C#)
```csharp
public FaceBasedPlacementType FaceBasedPlacementType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

