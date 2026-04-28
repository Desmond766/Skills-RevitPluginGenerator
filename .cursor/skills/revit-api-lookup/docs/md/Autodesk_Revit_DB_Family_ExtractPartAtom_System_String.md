---
kind: method
id: M:Autodesk.Revit.DB.Family.ExtractPartAtom(System.String)
zh: 族
source: html/d477cf8f-0dfe-4055-a787-315c84ef5530.htm
---
# Autodesk.Revit.DB.Family.ExtractPartAtom Method

**中文**: 族

Writes a PartAtom XML from the contents of a family object.

## Syntax (C#)
```csharp
public void ExtractPartAtom(
	string xmlFilePath
)
```

## Parameters
- **xmlFilePath** (`System.String`) - The xml file to be saved.

## Remarks
This method is designed for a family loaded into a document in session. So it will skip the type catalog file.
To extract the PartAtom XML from a family file on disk, use Application.ExtractPartAtomFromFamilyFile()

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'xmlFilePath' is Nothing nullptr a null reference ( Nothing in Visual Basic) or an empty string.

