---
kind: method
id: M:Autodesk.Revit.DB.LayerModifier.#ctor(Autodesk.Revit.DB.ModifierType,System.String)
source: html/6136a8fa-dcce-859b-8c71-c223dd0fd752.htm
---
# Autodesk.Revit.DB.LayerModifier.#ctor Method

Constructs a new LayerModifier with modifierType and separator.

## Syntax (C#)
```csharp
public LayerModifier(
	ModifierType modifierType,
	string separator
)
```

## Parameters
- **modifierType** (`Autodesk.Revit.DB.ModifierType`) - The modifier type.
- **separator** (`System.String`) - The separator string that will follow this modifier in the export layer name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided separator contains invalid characters (most special characters are invalid).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

