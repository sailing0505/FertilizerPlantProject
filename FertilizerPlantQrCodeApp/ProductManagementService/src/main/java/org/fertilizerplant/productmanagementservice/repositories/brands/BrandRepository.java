package org.fertilizerplant.productmanagementservice.repositories.brands;

import org.fertilizerplant.productmanagementservice.models.brands.Brand;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;
import org.springframework.stereotype.Repository;

@Repository
public interface BrandRepository extends JpaRepository<Brand,Long>,QueryDslPredicateExecutor<Brand>{
	
}