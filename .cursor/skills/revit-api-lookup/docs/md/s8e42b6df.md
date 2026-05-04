---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.IsTypeNameValidForCustomConnection(Autodesk.Revit.DB.Document,System.String)
source: html/1b1a9194-d048-7d41-eb53-94b9201e2a9b.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.IsTypeNameValidForCustomConnection Method

Validates if the input name matches the criteria of StructuralConnectionHandlerType name.
 Name must be unique among other existing StructuralConnectionHandlerTypes and cannot contain any of the following characters: new line, {}[];`~\\/:*?";<>| or any of the non-printable characters.

## Syntax (C#)
```csharp
public static bool IsTypeNameValidForCustomConnection(
	Document document,
	string typeName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeName** (`System.String`) - The StructuralConnectionHandlerType name to validate.

## Returns
True if the input name matches the criteria of StructuralConnectionHandlerType name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

