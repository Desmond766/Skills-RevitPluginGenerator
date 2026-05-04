---
kind: type
id: T:Autodesk.Revit.DB.TransmissionData
source: html/d78d1e9c-1cee-1336-88d5-b605dacd077d.htm
---
# Autodesk.Revit.DB.TransmissionData

A class representing information on all external file references
 in a document.

## Syntax (C#)
```csharp
public class TransmissionData : IDisposable
```

## Remarks
TransmissionData stores information on both the previous state
 and requested state of an external file reference.
 This means that it stores the load state and path of the reference
 from the most recent time this TransmissionData's document was opened.
 It also stores load state and path information for what Revit should
 do the next time the document is opened. As such, TransmissionData can be used to perform operations on external
 file references without having to open the entire associated Revit
 document. The methods ReadTransmissionData and WriteTransmissionData
 can be used to obtain information about external references, or to
 change that information. For example, calling WriteTransmissionData
 with a TransmissionData object which has had all references set to
 LinkedFileStatus.Unloaded would cause no references to be loaded
 upon next opening the document. TransmissionData cannot add or remove references to
 external files. If, on file open, Revit discovers information
 in the TransmissionData which does not correspond to an
 existing external file reference,
 the information will be ignored on file load. The TransmissionData for a document does not contain information
 about references which come from external servers. TransmissionData only
 contains references to local files or Revit links on Revit Server.
 TransmissionData cannot
 be used to change a reference from a local file reference to an external
 server reference. Note that TransmissionData objects must be set to "transmitted" for
 the requested reference data to be meaningful. Revit ignores the
 TransmissionData for non-transmitted files. Marking a file as
 transmitted has other effects - workshared files are opened as
 detached from the central model, and creation of new local files
 is prohibited, until the file is in its final location and the
 file has been marked as no longer transmitted.

