# Standard Digital Signature
Easy-to-use library for creating digital identities based on encryption and digital signature of document and validation of signatures.
The standard digital signature project has a universal target, and can be run on both Linux and Windows systems on x86, x64 and ARM platforms.
In this solution there are two projects, running on both linux and windows systems, the first consists of a library that allows the creation of cryptographic digital identities and to sign documents and validate the signatures issued by any user. The library is the essential part of the digital identity and signature software. The second project is a web interface that allows a user to interact with the library to affix digital signatures or proceed with the validation of digital signatures affixed by other users.

## What is a digital identity?
The identity is a cryptographic identity which consists in the possession of a pair of cryptographic keys (public and private) for asymmetric cryptography, the private key is technically the essential part of the identity, it allows to sign documents and the theft of the same corresponds to the theft of the digital identity, for this reason it must be kept in a safe way, for this purpose this project uses the secure storage library.
The public key, which can be freely distributed, is useful for validating the signature, and for communicating in an encrypted manner with whoever owns the private key.
The digital identity is initially anonymous (without a name and surname), whoever owns it can at any time prove that they are in possession of the private key by affixing a signature.
Technically it is possible to assign a first and last name to an anonymous digital identity through a KYC procedure, or by using another non-anonymous digital signature, to certify that the generated signature belongs to a known person. If you opt for the KYC, during the recognition procedure, the identity holder will have to use their digital identity to affix a signature demonstrating that they have the private key, and those who carry out the KYC procedure will have to store the data in a safe place concerning the holder of the digital identity and its public key.

## How is the digital signature done?
The digital signature is a cryptographic signature that can only be affixed by those in possession of the private key. The cryptographic key is not placed directly on the document to be signed but on a hash that proves the existence of the document, and a timestamp. In the calculation of the hash, a reference to the most recent closed bitcoin block is also added which acts as a timestamp, in this way it can be demonstrated with absolute certainty that the signature was affixed after the date of the block.

## Is it possible to add multiple signatures to the document?
The standard digital signature is not placed directly on the document to be signed but on a separate file, this has the advantage of keeping the original document unaltered which can easily continue to be viewed with a standard viewer. The digital signature is then placed on a separate file and therefore an unlimited number of joint signatures can be placed on the same document, simply an additional file will be created for each signature. The verification of the signature is then carried out by presenting the file of the original document with the files of the digital signatures created by the signatory subjects attached.

## Scalability and backwards compatibility
The digital signature has a version number that will be increased with each new introduction of new features. In this way the validation software will mark the verification criteria based on the version used to make the digital signature, and if new features have been introduced these will be active without affecting the compatibility of signed documents with older versions of the software.
The working group for the maintenance and development of the "digital signature standard". works continuously by introducing new features required by the market and by individual states, this means that the software will always be able to cover new needs and comply with the highest safety standards.

## Bitcoin technology
This project derives from the bitcoin technology and inherits from it the level of security, and the possibility of restoring the client-side account using the passphrase (exactly as happens for bitcoin wallets). Just as with bitcoin wallets, the accounts are client-side only, consisting of a private key, and there is no dependency on any backend to be executed).

## Usage examples
The DigitalSignatureWebUI project has two examples of using the standard library for digital signatures:
The Signature.razor file shows the programmer how to sign a document.
The SignatureValidation.razor file is a practical example of how to proceed with the validation of the signature on a document: First you need to select the original document, then the signature file and then proceed with the validation.


