package org.fertilizerplant.qrcodemanagementservice.services.qrcode.impl;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.repositories.qrcode.QrCodeRepository;
import org.fertilizerplant.qrcodemanagementservice.services.qrcode.QrCodeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Qualifier("qrcodeService")
public class DefaultQrCodeService implements QrCodeService {
	
	@Autowired
	private QrCodeRepository qrCodeRepository;

	public List<QrCode> getAllQrCodes() {
		return qrCodeRepository.findAll();
	}

	public QrCode save(QrCode qrCode) {
		return qrCodeRepository.save(qrCode);
	}

	public List<String> getAllQrCodeValues() {
		List<QrCode> qrcodes = getAllQrCodes();
		List<String> qrcodeValues = qrcodes.stream().map(q -> q.getEncodedValue()).collect(Collectors.toList());
		return qrcodeValues;
	}

	@Transactional 
	public void generateQrCodes(int number,String encodedValueWebrootPrefix)
    {
    	long alreadyUsed = qrCodeRepository.count();
    	List<QrCode> qrcodes = new ArrayList<QrCode>();
    	for(int i=0 ; i < number; i++)
    	{
    		QrCode qrcode = new QrCode();
    		qrcodes.add(qrcode);
        	String encodedValue = encodedValueWebrootPrefix + "/" + alreadyUsed++;
    		qrcode.setEncodedValue(encodedValue);
    	}
    	qrCodeRepository.bulkSave(qrcodes);
    }
}
