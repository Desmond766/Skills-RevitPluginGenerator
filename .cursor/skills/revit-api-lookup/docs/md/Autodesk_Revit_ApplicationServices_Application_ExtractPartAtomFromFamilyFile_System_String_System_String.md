---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.ExtractPartAtomFromFamilyFile(System.String,System.String)
source: html/1f2c631b-2733-0aa7-051c-42bccb07f05e.htm
---
# Autodesk.Revit.ApplicationServices.Application.ExtractPartAtomFromFamilyFile Method

Writes a PartAtom XML from the contents of a family file.

## Syntax (C#)
```csharp
public void ExtractPartAtomFromFamilyFile(
	string familyFilePath,
	string xmlFilePath
)
```

## Parameters
- **familyFilePath** (`System.String`) - The family file to be processed.
- **xmlFilePath** (`System.String`) - The xml file to be saved.

## Remarks
If there is a TXT type catalog next to the family file (a TXT file with the same name as the RFA file), 
the function will read it as well and process its contents into PartAtom. 
To extract a PartAtom XML from a family loaded into a document in session, use Family.ExtractPartAtom().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'familyFilePath' or 'xmlFilePath' is Nothing nullptr a null reference ( Nothing in Visual Basic) or an empty string or if the family file doesn't exist on disk.

